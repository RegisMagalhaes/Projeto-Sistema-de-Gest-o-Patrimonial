import React, { Component } from "react";
import api from "../../services/api";
import logo from "../../assets/img/logo-azul.png";

export default class CadEquipamento extends Component {
  constructor(props) {
    super(props);
    this.state = {
      Equipamento: {
        Descricao: "",
        Marca: "",
        Tipo: "",
        NumeroDeSerie: "",
        Status: "",
        numeroPatrimonio: "",
        idSala: "",
      },
    };
  }

  cadastrarEquipamento = (event) => {
    event.preventDefault();

    let equipamento = {
      Descricao: this.state.Equipamento.Descricao,
      Tipo: this.state.Equipamento.Tipo,
      Marca: this.state.Equipamento.Marca,
      numeroDeSerie: this.state.Equipamento.numeroDeSerie,
      numeroPatrimonio: this.state.Equipamento.numeroPatrimonio,
      status: this.state.Equipamento.status,
      idSala: this.state.Equipamento.idSala,
    };

    api
      .post("/Equipamento", equipamento)

      .then((resposta) => {
        if (resposta.status === 201) {
          alert("Equipamento cadastrado!");
        }
      })

      .catch((erro) => {
        alert(erro);
      });
  };

  atualizarState = (campo) => {
    this.setState((prevState) => ({
      Equipamento: {
        ...prevState.Equipamento,
        [campo.target.name]: campo.target.value,
      },
    }));
  };

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
                  <a href="/CadEquipamento">Cadastrar Equipamento</a>
                  <a href="/equipamentos">Todos os equipamentos</a>
                </div>
              </div>
              <div className="dropdown">
                <button className="dropbtn">
                  <i className="bx bxs-buildings"></i> Salas
                </button>
                <div className="dropdown-content">
                  <a href="/CadSala">Cadastrar Sala</a>
                  <a href="/Salas">Todos as Salas</a>
                </div>
              </div>
            </div>

            <main>
              <div ClassName="container-text">
                <h1>Cadastrar novo Equipamento</h1>
              </div>

              <section className="main-form">
                <form action="#" method="post">
                  <fieldset>
                    <div className="container-form">
                      <label htmlFor="nomeEquipamento">
                        Nome do Equipamento
                      </label>
                      <input
                        type="text"
                        name="nomeEquipamento"
                        id="nomeEquipamento"
                        required
                      />
                    </div>
                  </fieldset>
                  <fieldset>
                    <div className="container-form">
                      <label htmlFor="marca">Marca:</label>
                      <input type="text" name="marca" id="marca" required />
                    </div>
                    <div className="container-form">
                      <label htmlFor="numeroSerie">Número de série:</label>
                      <input
                        type="text"
                        name="numeroSerie"
                        id="numeroSerie"
                        required
                      />
                    </div>
                    <div className="container-form">
                      <label htmlFor="numeroDePatrimonio">
                        Número de Patrimônio:
                      </label>
                      <input
                        type="text"
                        name="numeroDePatrimonio"
                        id="numeroDePatrimonio"
                        required
                      />
                    </div>
                  </fieldset>

                  <fieldset>
                  <div className="container-form">
                    
                  </div>

                  <label for="cars">Sala:</label>
                    <select name="salas" id="salas">
                      <option value="value1">Fruits</option>
                    </select>
                    
                      
                  </fieldset>

                  <input
                    type="submit"
                    defaultValue="Cadastrar"
                    className="btn-login"
                  />
                </form>
              </section>
            </main>
          </div>
        </body>
      </div>
    );
  }
}
