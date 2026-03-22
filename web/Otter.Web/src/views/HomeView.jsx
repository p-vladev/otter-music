import Base from "../components/Base";

function HomeView() {

    return (
        <Base>
            {/* Main Content */}
            <main className="flex-1 p-8">
                <div className="max-w-4xl">
                    <h1 className="text-3xl font-bold mb-4">Welcome to Otter Music</h1>
                </div>
            </main>
        </Base>
    );
}

export default HomeView;