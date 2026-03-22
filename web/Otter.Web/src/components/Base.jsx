import Navbar from "./Navbar";
import SideNav from "./SideNav";

function Base({children}) {

    return (
        <div className="min-h-screen bg-black text-gray-200 flex flex-col">
            <Navbar />

            <div className="flex flex-1">
                <SideNav />

                {children}
            </div>
        </div>
    );
}

export default Base;