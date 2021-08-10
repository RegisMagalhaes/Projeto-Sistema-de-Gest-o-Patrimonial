import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Switch, Link} from 'react-router-dom';

import './index.css';


import Login from './pages/login/login';
import Equipamentos from './pages/equipamentos/equipamentos'
import Salas from './pages/salas/salas'
import CadEquipamentos from './pages/cadEquipamento/cadEquipamento'
import CadSala from './pages/cadSala/cadSala'
import EditSala from './pages/salas/editSala'
import EditEquipamento from './pages/equipamentos/editEquipamento'

import reportWebVitals from './reportWebVitals';


const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Login} /> 
        <Route exact path="/equipamentos" component={Equipamentos} /> 
        <Route exact path="/salas" component={Salas} />
        <Route exact path="/cadequipamentos" component={CadEquipamentos} />
        <Route exact path="/cadsala" component={CadSala} />
        <Route exact path="/salas/editSala/:idSala" component={EditSala} />
        <Route exact path="/equipamentos/editEquipamento/:idEquipamento" component={EditEquipamento} />
      </Switch>
    </div>
  </Router>
);

ReactDOM.render(routing, document.getElementById('root'));

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();