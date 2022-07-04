
import { BrowserRouter as Router, Route, Routes, Switch } from "react-router-dom"; import './App.css';
import Header from './component/Header'
import Dashboard from './component/Dashboard'
import Login from './component/login'
import 'bootstrap/dist/css/bootstrap.min.css';
import Signup from './component/Signup'
function App() {
  return (
    <Router>

      <Header />
      <div className="App">
        <Routes>
        <Route path="/" element={<Signup />} />
        <Route exact path="/login" element={<Login />} />
        <Route exact path="/Dashboard" element={<Dashboard />} />
        <Route path="*" element={<Signup />} />
        </Routes>
      </div>

    </Router>

  );
}

export default App;
