import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import { AuthProvider } from './contexts/AuthContext';
import HomeView from './views/HomeView';
import RegisterView from './views/RegisterView';
import LoginView from './views/LoginView';
import ProfileView from './views/ProfileView';

function App() {
  const router = createBrowserRouter([
    {
      path: '/',
      element: <HomeView />
    },
    {
      path: '/register',
      element: <RegisterView />
    },
    {
      path: '/login',
      element: <LoginView />
    },
    {
      path: '/profile',
      element: <ProfileView />
    }
  ]);

  return (
    <AuthProvider>
      <RouterProvider router={router} />
    </AuthProvider>
  )
}

export default App
