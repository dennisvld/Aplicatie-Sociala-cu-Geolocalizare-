import React, { useState } from 'react';
import axios from 'axios';

const ReviewForm = () => {
    const [rating, setRating] = useState(0);
    const [text, setText] = useState('');
    const [error, setError] = useState('');

    const handleSubmit = async (e) => {
        e.preventDefault();
        if (rating < 1 || rating > 5) {
            setError('Rating must be between 1 and 5');
            return;
        }
        if (text.trim() === '') {
            setError('Review text cannot be empty');
            return;
        }

        try {
            const response = await axios.post('/api/reviews', { rating, text });
            console.log('Review submitted:', response.data);
            setRating(0);
            setText('');
            setError('');
        } catch (err) {
            console.error('Error submitting review:', err);
            setError('Failed to submit review');
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label>Rating (out of 5):</label>
                <input
                    type="number"
                    value={rating}
                    onChange={(e) => setRating(Number(e.target.value))}
                    min="1"
                    max="5"
                />
            </div>
            <div>
                <label>Review:</label>
                <textarea
                    value={text}
                    onChange={(e) => setText(e.target.value)}
                />
            </div>
            {error && <p style={{ color: 'red' }}>{error}</p>}
            <button type="submit">Submit Review</button>
        </form>
    );
};

export default ReviewForm;