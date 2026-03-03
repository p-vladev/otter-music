import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import HomeView from './views/HomeView';
import RegisterView from './views/RegisterView';
import LoginView from './views/LoginView';

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
    }
  ]);

  return (
    <>
      <RouterProvider router={router} />
    </>
  )
}

export default App
