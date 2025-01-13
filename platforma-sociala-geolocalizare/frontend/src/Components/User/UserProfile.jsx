import React, { useState } from 'react';

const UserProfile = ({ user }) => {
    const [isEditing, setIsEditing] = useState(false);
    const [profileDetails, setProfileDetails] = useState({
        bio: user.bio,
        followers: user.followers,
        reviews: user.reviews,
        profilePicture: user.profilePicture,
    });

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setProfileDetails({
            ...profileDetails,
            [name]: value,
        });
    };

    const handleProfilePictureChange = (e) => {
        const file = e.target.files[0];
        const reader = new FileReader();
        reader.onloadend = () => {
            setProfileDetails({
                ...profileDetails,
                profilePicture: reader.result,
            });
        };
        reader.readAsDataURL(file);
    };

    const handleEditToggle = () => {
        setIsEditing(!isEditing);
    };

    const handleSave = () => {
        // Save profile details logic here
        setIsEditing(false);
    };

    return (
        <div className="user-profile">
            <div className="profile-picture">
                <img src={profileDetails.profilePicture} alt="Profile" />
                {isEditing && (
                    <input type="file" onChange={handleProfilePictureChange} />
                )}
            </div>
            <div className="profile-details">
                {isEditing ? (
                    <textarea
                        name="bio"
                        value={profileDetails.bio}
                        onChange={handleInputChange}
                    />
                ) : (
                    <p>{profileDetails.bio}</p>
                )}
                <p>Followers: {profileDetails.followers}</p>
                <p>Reviews: {profileDetails.reviews}</p>
            </div>
            <div className="profile-actions">
                {isEditing ? (
                    <button onClick={handleSave}>Save</button>
                ) : (
                    <button onClick={handleEditToggle}>Edit Profile</button>
                )}
            </div>
        </div>
    );
};

export default UserProfile;