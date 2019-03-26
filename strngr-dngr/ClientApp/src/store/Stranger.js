//import { StrangerService } from "../services/StrangerService";

import axios from "axios";

const addPhotoType = "ADD_PHOTO";
const addStrangerInfoType = "ADD_STRANGER_INFO";

const initialState = {
    photos: null,
    info: {
        firstName: undefined,
        lastName: undefined,
        age: undefined,
        education: undefined,
        job: undefined,
        location: undefined
    }
}

export const actionCreators = {
    addPhoto: (photos) => async (dispatch, getState) => {
        // Call API
        console.log(photos);

        var formData = new FormData();
        for(var i = 0; i < photos.length; ++i)
        {
            formData.append(`photo${i}`, photos[i]);
        }

        axios.post("api/PhotoProcessing/GetProcessedPhotoData", 
            formData
        ).then((resp) => {
                console.log(resp);
            }).catch((err) => {
                console.log(err);
            });

        return ({
            type: addPhotoType,
            photos
        });
    },
    addStranger: (info) => ({
        type: addStrangerInfoType,
        info
    })
};

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type === addPhotoType) {
        return { ...state, photos: action.photos }
    }

    if (action.type === addStrangerInfoType) {
        return { ...state, info: action.info }
    }

    return state;
};
