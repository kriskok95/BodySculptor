import React from 'react';

const Exercise = props => {
    const { name, imageUrl, mainMuscleGroupName, secondaryMuscleGroupNames } = props.exercise;

    return (
        <React.Fragment>
            <tr>
                <td>{name}</td>
                <td><img src={imageUrl} alt="Exercise Image" width="50" height="60" /></td>
                <td>{mainMuscleGroupName}</td>
                <td>{secondaryMuscleGroupNames.join(', ')}</td>
            </tr>
        </ React.Fragment >
    )
};

export default Exercise;