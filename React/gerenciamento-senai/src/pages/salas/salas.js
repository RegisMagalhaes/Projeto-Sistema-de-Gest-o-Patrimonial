import React, { Component } from "react";
import api from "../../services/api";
import logo from "../../assets/img/logo-azul.png";
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
      .catch((erro) => alert(erro));
  };

  componentDidMount() {
    this.buscarSalas();
    document.title = "Salas";
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
                  <a href="#">Novo Equipamento</a>
                  <a href="/equipamentos">Todos os equipamentos</a>
                </div>
              </div>
              <div className="dropdown">
                <button className="dropbtn">
                  <i className="bx bxs-buildings"></i> Salas
                </button>
                <div className="dropdown-content">
                  <a href="index.html">Nova Sala</a>
                  <a href="/Salas">Todos as Salas</a>
                </div>
              </div>
            </div>

            <main>
              <div ClassName="container-text">
                <h1>Salas</h1>
                <button className="btn">
                  <a href="">Adicionar nova Sala</a>
                </button>
              </div>

              <div class="main-header">
                <p>Sala</p>
                <p>Andar</p>
                <p>Metragem</p>
              </div>

              <section ClassName="main-equip">
                {this.state.listaSalas.map((Salas) => {
                  return (
                    <details>
                      <summary key={Salas.idSala}>
                        <p>{Salas.nome}</p>
                        <p>{Salas.andar}</p>
                        <p>{Salas.metragem} m²</p>
                      </summary>
                      <div class="content">
                        <div class="paragrafos">
                        <p>Número: {Salas.idSala}</p>
                        <p>Sala: {Salas.nome}</p>
                        <p>Andar: {Salas.andar}</p>
                        <p>Tamanho: {Salas.metragem}m²</p>
                        </div>
        
                          <a href="http://" class="btn-edit">
                            Editar
                          </a>
                    
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
