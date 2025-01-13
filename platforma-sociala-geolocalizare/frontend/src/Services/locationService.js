import axios from 'axios';

const API_URL = 'http://your-backend-api-url.com/api/locations';

const kmlService = {
    fetchLocations: async () => {
        try {
            const response = await axios.get(API_URL);
            return response.data;
        } catch (error) {
            console.error('Error fetching locations:', error);
            throw error;
        }
    },

    addLocation: async (locationData) => {
        try {
            const response = await axios.post(API_URL, locationData);
            return response.data;
        } catch (error) {
            console.error('Error adding location:', error);
            throw error;
        }
    },

    fetchMarkers: async () => {
        try {
            const response = await axios.get(`${API_URL}/markers`);
            return response.data;
        } catch (error) {
            console.error('Error fetching markers:', error);
            throw error;
        }
    }
};

export default kmlService;