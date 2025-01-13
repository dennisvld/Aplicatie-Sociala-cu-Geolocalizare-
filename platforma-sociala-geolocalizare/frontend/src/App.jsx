import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Home from './pages/Home';
import Location from './pages/Location';
import User from './pages/User';
import Navigation from './components/Navigation';
import { GlobalStateProvider } from './context/GlobalState';

function App() {
    return (
        <GlobalStateProvider>
            <Router>
                <Navigation />
                <Switch>
                    <Route exact path="/" component={Home} />
                    <Route path="/location" component={Location} />
                    <Route path="/user" component={User} />
                </Switch>
            </Router>
        </GlobalStateProvider>
    );
}

export default App;