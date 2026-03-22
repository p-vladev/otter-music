import { useNavigate } from "react-router-dom";
import { useAuth } from "../contexts/AuthContext";
import Base from "../components/Base";

function ProfileView() {
    const user = JSON.parse(localStorage.getItem("user"));
    const { logout } = useAuth();
    const navigate = useNavigate();

    console.log("User data:", user);

    const HandleLogout = () => {
        localStorage.removeItem("token");
        localStorage.removeItem("refreshToken");
        localStorage.removeItem("user");
        
        logout();
        navigate("/");
    }

    return (
        <Base>
            <main className="flex-1 p-8">
                <div className="max-w-4xl">
                    <div className="flex items-center gap-6 mb-8">
                        <div className="w-24 h-24 rounded-full bg-gray-800" />

                        <div>
                            <h1 className="text-2xl font-bold">{user.username}</h1>
                            <p className="text-gray-400">{user.email}</p>
                        </div>

                        <button onClick={() => HandleLogout()} className="ml-auto px-4 py-2 bg-red-600 text-white rounded-lg hover:bg-red-700">
                            Exit
                        </button>
                    </div>

                    <div className="border border-gray-800 rounded-xl p-6 bg-gray-950">
                        <h2 className="text-lg font-semibold mb-4">Profile Info</h2>
                        <div className="grid gap-4 text-sm">
                            <div className="flex justify-between border-b border-gray-800 pb-2">
                                <span className="text-gray-400">Name</span>
                                <span>{user.firstName} {user.lastName}</span>
                            </div>
                            <div className="flex justify-between border-b border-gray-800 pb-2">
                                <span className="text-gray-400">Email</span>
                                <span>{user.email}</span>
                            </div>
                            <div className="flex justify-between">
                                <span className="text-gray-400">Joined</span>
                                <span>2024</span>
                            </div>
                        </div>
                    </div>
                </div>
            </main>
        </Base>
    );
}

export default ProfileView;