import { useState, useEffect } from 'react';

const useAuth = () => {
    const [user, setUser] = useState(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        // Simulate fetching user data from an API or local storage
        const fetchUser = async () => {
            const storedUser = localStorage.getItem('user');
            if (storedUser) {
                setUser(JSON.parse(storedUser));
            }
            setLoading(false);
        };

        fetchUser();
    }, []);

    const login = (userData) => {
        // Simulate login by setting user data and storing it in local storage
        setUser(userData);
        localStorage.setItem('user', JSON.stringify(userData));
    };

    const logout = () => {
        // Simulate logout by clearing user data and removing it from local storage
        setUser(null);
        localStorage.removeItem('user');
    };

    const getCurrentUser = () => {
        return user;
    };

    return {
        user,
        loading,
        login,
        logout,
        getCurrentUser,
    };
};

export default useAuth;