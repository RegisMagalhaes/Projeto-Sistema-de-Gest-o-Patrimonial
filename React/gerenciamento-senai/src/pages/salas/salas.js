import React, { Component } from "react";
import api from "../../services/api";
import logo from "../../assets/img/logo-azul.png";
import swal from 'sweetalert';

export default class Salas extends Component {
  constructor(props) {
    super(props);
    this.state = {
      listaSalas: [],
      Salas: {
        andar: "",
        nome: "",
        metragem: "",
      },
    };
  }

  buscarSalas = () => {
    api.get("/Sala")
      .then((resposta) => {
        if (resposta.status === 200) {
          this.setState({ listaSalas: resposta.data });
        }
      })
      .catch((erro) => swal("Ocorreu um erro :(", `${erro}`, "error"));
  };

  deletarSala = (Salas) => {
    this.setState({
        idSala : Salas.idSala
    })
    api.delete('/Sala/' + Salas.idSala )
    .then(resposta => {
        if (resposta.status === 204) {
          swal("Sucesso!", "A Sala foi deletada com Sucesso!", "success");
        }
    })
    .catch((erro) => swal("Ocorreu um erro :(", `${erro}`, "error"))
    .then(this.buscarSalas)
}

  componentDidMount() {
    this.buscarSalas();
    document.title = "Todas as Salas";
  }

  render() {
    return (
      <div>
        <meta charSet="UTF-8" />
        <link rel="stylesheet" href="css/style.css" />
        {/* Boxiocns CDN Link */}
        <link
          href="https://unpkg.com/boxicons@2.0.9/css/boxicons.min.css"
          rel="stylesheet"
        />
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <body>
          <div className="container">
            <div className="menu-lateral">
              <img src={logo} />
              <div className="dropdown">
                <button className="dropbtn">
                  <i className="bx bxs-microchip"></i> Equipamentos
                </button>
                <div className="dropdown-content">
                  <a href="/CadEquipamentos">Cadastrar Equipamento</a>
                  <a href="/equipamentos">Todos os equipamentos</a>
                </div>
              </div>
              <div className="dropdown">
                <button className="dropbtn">
                  <i className="bx bxs-buildings"></i> Salas
                </button>
                <div className="dropdown-content">
                  <a href="/CadSala">Cadastrar Sala</a>
                  <a href="/Salas">Todas as Salas</a>
                </div>
              </div>
            </div>

            <main>
              <div className="container-text">
                <h1>Salas</h1>
                <button className="btn">
                  <a href="/CadSala">Adicionar nova Sala</a>
                </button>
              </div>

              <div className="main-header">
                <p>Sala</p>
                <p>Andar</p>
                <p>Metragem</p>
              </div>

              <section className="main-equip">
                {this.state.listaSalas.map((Salas) => {
                  return (
                    <details>
                      <summary key={Salas.idSala}>
                        <p>{Salas.nome}</p>
                        <p>{Salas.andar}</p>
                        <p>{Salas.metragem} m²</p>
                      </summary>
                      <div className="content">
                        <div className="paragrafos">
                        <p>Sala: {Salas.nome}</p>
                        <p>Andar: {Salas.andar}</p>
                        <p>Tamanho: {Salas.metragem}m²</p>
                        <p>Equipamentos: {Salas.IdEquipamentoNavigation}</p>
                        </div>
                        <div className="botoes">
                        <a className="btn-edit">Editar</a>
                        <a className="btn-del" onClick={() => this.deletarSala(Salas)}>Deletar</a>
                        </div>
                      </div>
                    </details>
                  );
                })}
              </section>
            </main>
          </div>
        </body>
      </div>
    );
  }
}
