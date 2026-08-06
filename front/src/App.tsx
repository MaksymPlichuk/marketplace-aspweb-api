import './App.css'
import {Route, Routes} from "react-router";
import DefaultLayout from "./components/layout/DefaultLayout.tsx";
import MainPage from "./pages/MainPage.tsx";
import ItemsPage from "./pages/Items/ItemsPage.tsx";

function App() {
    return (
        <>
            <Routes>
                <Route path="/" element={<DefaultLayout/>}>
                    <Route index element={<MainPage/>}/>
                    <Route path="/items" element={<ItemsPage/>}/>
                </Route>
            </Routes>
        </>
    )
}

export default App
