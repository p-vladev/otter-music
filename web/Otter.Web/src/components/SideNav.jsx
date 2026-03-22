function SideNav() {

    return (
        <aside className="w-64 border-r border-gray-800 p-6 hidden md:flex md:flex-col">
            <nav className="flex flex-col gap-4 text-sm">
                <a href="#" className="hover:text-white">Home</a>
                <a href="#" className="hover:text-white">Library</a>
            </nav>
            <h2 className="text-xl font-semibold mt-8">Playlists</h2>
        </aside>
    );
}

export default SideNav;