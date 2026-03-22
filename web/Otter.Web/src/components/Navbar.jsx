import { useState, useEffect } from "react";
import { useAuth } from "../contexts/AuthContext";
import { Link } from "react-router-dom";

function Navbar() {
    const { isLoggedIn } = useAuth();

    return(
        <header className="w-full border-b border-gray-800 px-6 py-4 flex items-center gap-6">
            <Link to="/">
                <div className="text-lg font-bold">OtterMusic</div>
            </Link>

            {/* Search Bar */}
            <div className="flex-1 max-w-xl">
            <input
                type="text"
                placeholder="Search..."
                className="w-full bg-gray-900 border border-gray-800 rounded-lg px-4 py-2 text-sm placeholder-gray-500 focus:outline-none focus:border-gray-600"
            />
            </div>

            <div className="flex items-center gap-4 text-sm ml-auto">
                {!isLoggedIn 
                ?   <>
                        <Link to="/login" className="hover:text-white">Login</Link>
                        <Link to="/register" className="px-3 py-1 rounded-lg border border-gray-700 hover:border-gray-500">
                            Sign up
                        </Link>
                    </>
                :   <Link to="/profile" className="px-3 py-1 rounded-lg border border-gray-700 hover:border-gray-500">Profile</Link>}
            </div>
        </header>
    );
}

export default Navbar;