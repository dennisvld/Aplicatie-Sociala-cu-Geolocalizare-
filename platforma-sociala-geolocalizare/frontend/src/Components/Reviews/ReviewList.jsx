import React, { useState, useEffect } from 'react';
import axios from 'axios';

const ReviewList = ({ locationId }) => {
    const [reviews, setReviews] = useState([]);
    const [sortType, setSortType] = useState('date');

    useEffect(() => {
        const fetchReviews = async () => {
            try {
                const response = await axios.get(`/api/locations/${locationId}/reviews`);
                setReviews(response.data);
            } catch (error) {
                console.error('Error fetching reviews:', error);
            }
        };

        fetchReviews();
    }, [locationId]);

    const handleSortChange = (e) => {
        setSortType(e.target.value);
    };

    const handleLike = async (reviewId) => {
        try {
            await axios.post(`/api/reviews/${reviewId}/like`);
            setReviews((prevReviews) =>
                prevReviews.map((review) =>
                    review.id === reviewId ? { ...review, likes: review.likes + 1 } : review
                )
            );
        } catch (error) {
            console.error('Error liking review:', error);
        }
    };

    const sortedReviews = [...reviews].sort((a, b) => {
        if (sortType === 'date') {
            return new Date(b.date) - new Date(a.date);
        } else if (sortType === 'rating') {
            return b.rating - a.rating;
        }
        return 0;
    });

    return (
        <div>
            <h2>Reviews</h2>
            <label>
                Sort by:
                <select value={sortType} onChange={handleSortChange}>
                    <option value="date">Date</option>
                    <option value="rating">Rating</option>
                </select>
            </label>
            <ul>
                {sortedReviews.map((review) => (
                    <li key={review.id}>
                        <p>{review.text}</p>
                        <p>Rating: {review.rating}</p>
                        <p>Date: {new Date(review.date).toLocaleDateString()}</p>
                        <button onClick={() => handleLike(review.id)}>Like ({review.likes})</button>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default ReviewList;