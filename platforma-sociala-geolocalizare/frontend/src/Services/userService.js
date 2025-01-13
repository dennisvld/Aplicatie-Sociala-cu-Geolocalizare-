import axios from 'axios';

const API_URL = 'http://your-backend-url/api/users/';

const register = (userData) => {
    return axios.post(API_URL + 'register', userData);
};

const login = (userData) => {
    return axios.post(API_URL + 'login', userData);
};

const updateProfile = (userId, userData) => {
    return axios.put(API_URL + userId, userData);
};

const fetchUserData = (userId) => {
    return axios.get(API_URL + userId);
};

export default {
    register,
    login,
    updateProfile,
    fetchUserData
};