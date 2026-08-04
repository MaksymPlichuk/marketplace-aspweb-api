import './App.css'
import {Route, Routes} from "react-router";
import DefaultLayout from "./components/layout/DefaultLayout.tsx";
import MainPage from "./pages/MainPage.tsx";

function App() {
    return (
        <>
            <Routes>
                <Route path="/" element={<DefaultLayout/>}>
                    <Route index element={<MainPage/>}/>
                </Route>
            </Routes>
        </>
    )
}

export default App
