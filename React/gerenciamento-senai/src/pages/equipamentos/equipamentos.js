import React, { Component } from "react";
import "../equipamentos/equipamentos.css";
import api from "../../services/api";
import logo from "../../assets/img/logo-azul.png";

export default class Equipamentos extends Component {
  constructor(props) {
    super(props);
    this.state = {
      listaEquipamentos: [],
      Equipamentos: {
        descricao: "",
        tipo: "",
        marca: "",
        numeroDeSerie: "",
        NumeroPatrimonio: "",
        descricao: "",
        status: "",
      },
    };
  }

  buscarEquipamentos = () => {
    api.get("/Equipamento")

      .then((resposta) => {
        if (resposta.status === 200) {
          this.setState({ listaEquipamentos: resposta.data });
        }
      })
      .catch((erro) => alert(erro));
  };

  
  componentDidMount() {
    this.buscarEquipamentos();
    document.title = "Equipamentos";
  }

  render() {
    return (
      <div>
        <meta charSet="UTF-8" />
        <title>Index</title>
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
                  <a href="/CadEquipamentos">Novo Equipamento</a>
                  <a href="/equipamentos">Todos os equipamentos</a>
                </div>
              </div>
              <div className="dropdown">
                <button className="dropbtn">
                  <i className="bx bxs-buildings"></i> Salas
                </button>
                <div className="dropdown-content">
                  <a href="index.html">Nova Sala</a>
                  <a href="/salas">Todas as Salas</a>
                </div>
              </div>

            </div>

            <main>
              <div ClassName="container-text">
                <h1>Equipamentos</h1>
                <button className="btn">
                  <a href="/CadEquipamentos">Adicionar Novo Equipamento</a>
                </button>
              </div>

              <div class="main-header">
                <p>Nome</p>
                <p>Número de série</p>
                <p>Marca</p>
                <p>Status</p>
              </div>

              <section ClassName="main-equip">
                {this.state.listaEquipamentos.map((equipamento) => {
                  return (
                    <details>
                      <summary key={equipamento.idEquipamento}>
                        <p>{equipamento.descricao}</p>
                        <p>{equipamento.numeroDeSerie}</p>
                        <p>{equipamento.marca}</p>
                        <p>{equipamento.status}</p>
                      </summary>
                      <div class="content">
                        <div class="paragrafos">
                        <p>Nome: {equipamento.descricao}</p>
                        <p>Número de Série: {equipamento.numeroDeSerie}</p>
                        <p>Marca: {equipamento.marca}</p>
                        <p>Status: {equipamento.status}</p>
                        <p>Sala: {equipamento.idSala}</p>
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
