import axios from 'axios';

const API_URL = 'http://your-backend-api-url.com/api/reviews';

const reviewService = {
    fetchReviews: async () => {
        try {
            const response = await axios.get(API_URL);
            return response.data;
        } catch (error) {
            console.error('Error fetching reviews:', error);
            throw error;
        }
    },

    postReview: async (reviewData) => {
        try {
            const response = await axios.post(API_URL, reviewData);
            return response.data;
        } catch (error) {
            console.error('Error posting review:', error);
            throw error;
        }
    },

    likeReview: async (reviewId) => {
        try {
            const response = await axios.post(`${API_URL}/${reviewId}/like`);
            return response.data;
        } catch (error) {
            console.error('Error liking review:', error);
            throw error;
        }
    }
};

export default reviewService;