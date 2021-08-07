import React, { Component } from 'react'
import api from '../../services/api'
import { parseJwt } from '../../services/auth';
import logo from '../../assets/img/logo-login.png'
import '../login/login.css'

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

        api.post("/usuario", {
            email: this.state.user.email,
            senha: this.state.user.senha
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    this.setState({ isLoading: false })

                    localStorage.setItem("jwt", resposta.data.token)

                    console.log(this.props.history)
                    if(parseJwt().role === "1"){
                        this.props.history.push('/equipamento')
                    }
                    else{
                        alert("Usuário ou senha Incorretos. Tente novamente")
                        this.props.history.push('/')
                    }
                }
            })
            .catch(error => {
                alert(error)
            })
    }

    updateState = (campo) => {
        this.setState(prevState => ({
            user: {
                ...prevState.user,
                [campo.target.name]: campo.target.value
            }
        }))
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
                <input type="password" name="password" Value={this.state.user.senha} onChange={this.updateState} className="form-input" required/>
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

