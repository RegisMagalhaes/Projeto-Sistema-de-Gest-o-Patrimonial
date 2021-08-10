import React, { Component } from 'react'
import api from '../../services/api'
import { parseJwt } from '../../services/auth';
import logo from '../../assets/img/logo-login.png'
import '../login/login.css'
import swal from 'sweetalert';

export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            user: {
                email: "",
                senha: ""
            },

            isLoading: false
        }
    }

    funcaoLogin = (event) => {
        event.preventDefault();
        this.setState({ isLoading: true })

        api.post('/LoginView', {
            email: this.state.user.email,
            senha: this.state.user.senha
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    this.setState({ isLoading: false })
                    localStorage.setItem("jwt", resposta.data.token)

                    if(parseJwt().role === "1"){
                        this.props.history.push('/salas')
                    }
                    else{
                        swal("Ocorreu um erro!", "Usuário ou senha incorretos. Tente novamente", "error")
                        this.props.history.push('/')
                    }
                }
            })
            .catch((erro) => swal("Ocorreu um erro :(", `${erro}`, "error"));
    }

    updateState = (campo) => {
        this.setState(prevState => ({
            user: {
                ...prevState.user,
                [campo.target.name]: campo.target.value
            }
        }))
    }

    componentDidMount() {
      document.title = "Login";
    }

  render() {
    return (
      <div>
        <meta charSet="UTF-8" />
        <meta httpEquiv="X-UA-Compatible" content="IE=edge" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <title>Login</title>
        <link rel="stylesheet" href="css/style.css" />
        <main className="main-login">
          <div className="container-login">
            <form onSubmit={this.funcaoLogin}>
              <img src={logo} alt="Login Gerenciamento" srcSet />

              <div className="form-inputs">
                <label htmlFor>LOGIN</label>
                <input type="email" name="email" value={this.state.user.email} onChange={this.updateState} className="form-input" required/>
              </div>

              <div className="form-inputs">
                <label htmlFor>SENHA</label>
                <input type="password" name="senha" Value={this.state.user.senha} onChange={this.updateState} className="form-input" required/>
              </div>
              <input
                type="submit"
                defaultValue="Entrar"
                className="btn-login"
              />
            </form>
          </div>
        </main>
      </div>
    );
  }
}

