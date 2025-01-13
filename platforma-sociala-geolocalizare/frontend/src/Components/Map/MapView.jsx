import React, { useEffect } from 'react';

const MapView = () => {
    useEffect(() => {
        const initMap = () => {
            const map = new window.google.maps.Map(document.getElementById('map'), {
                center: { lat: 44.31, lng: 23.80 },
                zoom: 13,
                disableDefaultUI: true, // Disables all default UI
                zoomControl: true, // Enables zoom control
                mapTypeControl: true, // Enables map type control
                scaleControl: true, // Enables scale control
                streetViewControl: true, // Enables street view control
                rotateControl: true, // Enables rotate control
                fullscreenControl: true, // Enables fullscreen control
                mapTypeId: "satellite"
            });
        };

        if (!window.google) {
            const script = document.createElement('script');
            script.src = `https://maps.googleapis.com/maps/api/js?key=YOUR_ACTUAL_API_KEY`;
            script.async = true;
            script.defer = true;
            script.onload = initMap;
            document.head.appendChild(script);
        } else {
            initMap();
        }
    }, []);

    return <div id="map" style={{ height: '100vh', width: '100%' }} />;
};

export default MapView;