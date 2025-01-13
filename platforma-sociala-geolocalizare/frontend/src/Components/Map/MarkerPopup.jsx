import React, { useState } from 'react';
import { Popup } from 'react-leaflet';
import PropTypes from 'prop-types';

const MarkerPopup = ({ location, averageRating, onMoreInfoClick, onWriteReviewClick }) => {
    const [isOpen, setIsOpen] = useState(false);

    const handlePopupOpen = () => {
        setIsOpen(true);
    };

    const handlePopupClose = () => {
        setIsOpen(false);
    };

    return (
        <Popup
            position={location.coordinates}
            onOpen={handlePopupOpen}
            onClose={handlePopupClose}
        >
            <div>
                <h3>{location.name}</h3>
                <p>{location.description}</p>
                <p>Average Rating: {averageRating}</p>
                <button onClick={onMoreInfoClick}>More Info</button>
                <button onClick={onWriteReviewClick}>Write a Review</button>
            </div>
        </Popup>
    );
};

MarkerPopup.propTypes = {
    location: PropTypes.shape({
        name: PropTypes.string.isRequired,
        description: PropTypes.string.isRequired,
        coordinates: PropTypes.arrayOf(PropTypes.number).isRequired,
    }).isRequired,
    averageRating: PropTypes.number.isRequired,
    onMoreInfoClick: PropTypes.func.isRequired,
    onWriteReviewClick: PropTypes.func.isRequired,
};

export default MarkerPopup;