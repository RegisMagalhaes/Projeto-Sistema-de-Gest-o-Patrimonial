import React, { Component } from "react";
import api from "../../services/api";
import logo from "../../assets/img/logo-azul.png";
import swal from 'sweetalert';


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
        NumeroPatrimonio: ""
      },
    };
  }

  cadastrarEquipamento = (event) => {
    event.preventDefault();
    let equipamento = {
      Descricao: this.state.Equipamento.Descricao,
      Tipo: this.state.Equipamento.Tipo,
      Marca: this.state.Equipamento.Marca,
      NumeroDeSerie: this.state.Equipamento.NumeroDeSerie,
      NumeroPatrimonio: this.state.Equipamento.NumeroPatrimonio,
      status: this.state.Equipamento.status,
    };

    api.post("/Equipamento", equipamento)

      .then((resposta) => {
        if (resposta.status === 201) {
          swal("Sucesso!", "O Equipamento foi cadastrado com sucesso!", "success");
        }
      })

      .catch((erro) => swal("Ocorreu um erro :(", `${erro}`, "error"));
  };

  updateState = (campo) => {
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
                <form onSubmit={this.cadastrarEquipamento}>
                  <fieldset>
                    <div className="container-form">
                      <label htmlFor="nomeEquipamento">
                        Nome do Equipamento
                      </label>
                      <input
                        type="text"
                        name="Descricao"
                        id="Descricao"
                        value={this.state.Equipamento.Descricao}
                        onChange={this.updateState}
                        required
                      />
                     
                    </div>
                  </fieldset>
                  <fieldset>
                    <div className="container-form">
                      <label htmlFor="marca">Marca:</label>
                      <input type="text" name="Marca" id="Marca" value={this.state.Equipamento.Marca} onChange={this.updateState} required />
                    </div>
                    <div className="container-form">
                      <label htmlFor="NumeroDeSerie">Número de série:</label>
                      <input
                        type="text"
                        name="NumeroDeSerie"
                        id="NumeroDeSerie"
                        value={this.state.Equipamento.NumeroDeSerie}
                        onChange={this.updateState}
                        required
                      />
                    </div>
                    <div className="container-form">
                      <label htmlFor="NumeroPatrimonio">
                        Número de Patrimônio:
                      </label>
                      <input
                        type="text"
                        name="NumeroPatrimonio"
                        id="NumeroPatrimonio"
                        value={this.state.Equipamento.NumeroPatrimonio}
                        onChange={this.updateState}
                        required
                      />
                    </div>

                    <div className="container-form">
                      <label htmlFor="Status">
                        Status:
                      </label>
                      <input
                        type="text"
                        name="status"
                        id="status"
                        value={this.state.Equipamento.status}
                        onChange={this.updateState}

                        required
                      />
                    </div>
                    <div className="container-form">
                      <label htmlFor="Tipo">
                        Tipo
                      </label>
                      <input
                        type="text"
                        name="Tipo"
                        id="Tipo"
                        value={this.state.Equipamento.Tipo}
                        onChange={this.updateState}
                        required
                      />
                    </div>
                  </fieldset>

                  <fieldset>
                  
                      
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
