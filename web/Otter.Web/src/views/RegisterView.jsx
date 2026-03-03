import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import axios from "axios";

function RegisterView() {
        
    const API_URL = import.meta.env.VITE_API_URL;
    const navigate = useNavigate();

    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [username, setUsername] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const HandleSubmit = async (e) => {
        e.preventDefault();

        try {
            const res = await axios.post(`${API_URL}/Auth/register`, {
                firstName,
                lastName,
                username,
                email,
                password,
            });

            console.log("Registration successful:", res.data);

            navigate("/");
        } catch (error) {
            console.error("Registration error:", error);
        }
    }

    return (
        <>
            <div className="flex min-h-screen items-center justify-center bg-black px-4">
                <div className="w-full max-w-md bg-dark p-8 border-t-5 border-gray-500 border-be-1">
                    <h2 className="mb-6 text-center text-3xl font-bold text-white">Register</h2>
                    
                    <form className="space-y-4" onSubmit={HandleSubmit}>
                    <div>
                        <label className="mb-2 block text-sm font-medium text-gray-300">
                        First Name
                        </label>
                        <input 
                        value={firstName}
                        onChange={e => setFirstName(e.target.value)}
                        className="w-full rounded-md border border-gray-600 bg-gray-700 px-4 py-2 text-white placeholder-gray-400 focus:border-blue-500 focus:outline-none focus:ring-1 focus:ring-blue-500" 
                        type="text" 
                        id="first-name" 
                        placeholder="First Name" 
                        />

                        <label className="mb-2 block text-sm font-medium text-gray-300">
                        Last Name
                        </label>
                        <input 
                        value={lastName}
                        onChange={e => setLastName(e.target.value)}
                        className="w-full rounded-md border border-gray-600 bg-gray-700 px-4 py-2 text-white placeholder-gray-400 focus:border-blue-500 focus:outline-none focus:ring-1 focus:ring-blue-500" 
                        type="text" 
                        id="last-name" 
                        placeholder="Last Name" 
                        />
                    </div>

                    <div>
                        <label className="mb-2 block text-sm font-medium text-gray-300">
                        Username
                        </label>
                        <input 
                        value={username}
                        onChange={e => setUsername(e.target.value)}
                        className="w-full rounded-md border border-gray-600 bg-gray-700 px-4 py-2 text-white placeholder-gray-400 focus:border-blue-500 focus:outline-none focus:ring-1 focus:ring-blue-500" 
                        type="text" 
                        id="username" 
                        placeholder="Username" 
                        />
                    </div>

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

                    {/* <div>
                        <label className="mb-2 block text-sm font-medium text-gray-300">
                        Підтвердження пароля
                        </label>
                        <input 
                        className="w-full rounded-md border border-gray-600 bg-gray-700 px-4 py-2 text-white placeholder-gray-400 focus:border-blue-500 focus:outline-none focus:ring-1 focus:ring-blue-500" 
                        type="password" 
                        id="confirm-password" 
                        />
                    </div> */}
                    
                    <button 
                        className="mt-6 w-full rounded-md bg-blue-600 px-4 py-2 text-white transition-colors hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-offset-2 focus:ring-offset-gray-800" 
                        type="submit"
                    >
                        Sign Up
                    </button>
                    </form>
                    
                    <p className="mt-4 text-center text-sm text-gray-400">
                    Already have an account?{' '}
                    <Link to="/login" className="font-medium text-blue-500 hover:text-blue-400">
                        Log in
                    </Link>
                    </p>
                </div>
            </div>
        </>
    );
}

export default RegisterView;