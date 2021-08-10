import React, { Component } from "react";
import api from "../../services/api";
import logo from "../../assets/img/logo-azul.png";
import swal from 'sweetalert';


export default class editSala extends Component {
  constructor(props) {
    super(props);
    this.state = {
      Sala: {
        nome: "",
        andar: "",
        metragem: "",
      },
    };
  }

  editarSala = (event) => {
    event.preventDefault();

    let sala = {
      nome: this.state.Sala.nome,
      andar: this.state.Sala.andar,
      metragem: this.state.Sala.metragem,
    };

    api.post("/Sala", sala)

      .then((resposta) => {
        if (resposta.status === 201) {
          swal("Sucesso!", `A Sala "${this.state.Sala.nome}" foi cadastrada com sucesso!`, "success").then(function() {
            window.location = "/Salas";
        });;
        }
      })
      .catch((erro) => swal("Ocorreu um erro :(", `${erro}`, "error"));
  };

  updateState = (campo) => {
    this.setState((prevState) => ({
      Sala: {
        ...prevState.Sala,
        [campo.target.name]: campo.target.value,
      },
    }));
  };

  componentDidMount() {
    document.title = "Cadastrar Sala";
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
              <a href="/Salas" className="link-redirect">Retornar para todas as Salas</a>
              <div ClassName="container-text">
                <h1>Editar Sala</h1>
              </div>

              <section className="main-form">
                <form onSubmit={this.editarSala}>
                  <fieldset>
                    <div className="container-form">
                      <label htmlFor="nome">Nome da Sala</label>
                      <input
                        type="text"
                        name="nome"
                        id="nome"
                        value={this.state.Sala.nome}
                        onChange={this.updateState}
                        required
                      />
                    </div>
                  </fieldset>
                  <fieldset>
                    <div className="container-form">
                      <label htmlFor="marca">Andar</label>
                      <input
                        type="text"
                        name="andar"
                        id="andar"
                        value={this.state.Sala.andar}
                        onChange={this.updateState}
                        required
                      />
                    </div>
                    <div className="container-form">
                      <label htmlFor="numeroSerie">Metragem</label>
                      <input
                        type="number"
                        name="metragem"
                        id="metragem"
                        value={this.state.Sala.metragem}
                        onChange={this.updateState}
                        required
                      />
                    </div>
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
