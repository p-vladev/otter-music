import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import axios from "axios";

function LoginView() {
    
    const API_URL = import.meta.env.VITE_API_URL;
    const navigate = useNavigate();

    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const HandleSubmit = async (e) => {
        e.preventDefault();

        try {
            const res = await axios.post(`${API_URL}/Auth/login`, {
                email,
                password,
            });

            console.log("Login successful:", res.data);

            navigate("/");
        } catch (error) {
            console.error("Login error:", error);
        }
    }

    return (
        <>
            <div className="flex min-h-screen items-center justify-center bg-black px-4">
                <div className="w-full max-w-md bg-dark p-8 border-t-5 border-gray-500 border-be-1">
                    <h2 className="mb-6 text-center text-3xl font-bold text-white">Login</h2>
                    
                    <form className="space-y-5" onSubmit={HandleSubmit}>
                    <div>
                        <label className="mb-2 block text-sm font-medium text-gray-300">
                            Email
                        </label>
                        <input 
                        value={email}
                        onChange={e => setEmail(e.target.value)}
                        className="w-full rounded-md border border-gray-600 bg-gray-700 px-4 py-2 text-white placeholder-gray-400 focus:border-blue-500 focus:outline-none focus:ring-1 focus:ring-blue-500" 
                        type="email" 
                        id="email" 
                        placeholder="name@example.com" 
                        />
                    </div>
                    
                    <div>
                        <label className="mb-2 block text-sm font-medium text-gray-300">
                            Password
                        </label>
                        <input 
                        value={password}
                        onChange={e => setPassword(e.target.value)}
                        className="w-full rounded-md border border-gray-600 bg-gray-700 px-4 py-2 text-white placeholder-gray-400 focus:border-blue-500 focus:outline-none focus:ring-1 focus:ring-blue-500" 
                        type="password" 
                        id="password" 
                        />
                    </div>
                    
                    <button 
                        className="w-full rounded-md bg-blue-600 px-4 py-2 text-white transition-colors hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-offset-2 focus:ring-offset-gray-800" 
                        type="submit"
                    >
                        Sign In
                    </button>
                    </form>
                    
                    <p className="mt-4 text-center text-sm text-gray-400">
                        Still not have an account?{' '}
                    <Link to="/register" className="font-medium text-blue-500 hover:text-blue-400">
                        Register
                    </Link>
                    </p>
                </div>
            </div>
        </>
    );
}

export default LoginView;