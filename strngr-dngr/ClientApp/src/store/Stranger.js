import { StrangerService } from "../services/StrangerService";

const addPhotoType = "ADD_PHOTO";
const processPhotoType = "PROCESS_PHOTO";
const reverseImageSearchType = "REVERSE_IMAGE_SEARCH";
const addStrangerInfoType = "ADD_STRANGER_INFO";

const initialState = {
    photos: null,
    processedPhotoResults: null,
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
        dispatch({
            type: addPhotoType,
            photos
        });

        // Photo processing API
        var processedPhotoResults = StrangerService.processPhotos(photos);
        dispatch({
            type: processPhotoType,
            processedPhotoResults
        });
        
        // Reverse image search API
        var reverseImageSearchResults = StrangerService.reverseImageSearch(photos);
        dispatch({
            type: reverseImageSearchType,
            reverseImageSearchResults
        });
    },
    addStranger: (info) => async (dispatch, getState) => {
        dispatch({
            type: addStrangerInfoType,
            info
        });
    }
};

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type == addPhotoType) {
        return { ...state, photos: action.photos }
    }

    if (action.type === processPhotoType) {
        return { ...state, processedPhotoResults: action.processedPhotoResults }
    }
    
    if (action.type === reverseImageSearchType) {
        return { ...state, reverseImageSearchResults: action.reverseImageSearchResults }
    }

    if (action.type === addStrangerInfoType) {
        return { ...state, info: action.info }
    }

    return state;
};
