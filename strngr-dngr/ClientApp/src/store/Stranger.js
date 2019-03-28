import { StrangerService } from "../services/StrangerService";

const addPhotoType = "ADD_PHOTO";
const processPhotoType = "PROCESS_PHOTO";
const reverseImageSearchType = "REVERSE_IMAGE_SEARCH";
const addStrangerInfoType = "ADD_STRANGER_INFO";
const identityCheckType = "CHECK_IDENTITY";

const initialState = {
    photos: null,
    processedPhotoResults: null,
    reverseImageSearchResults: null,
    info: null,
    identityCheckResults: null
}

export const actionCreators = {
    addPhoto: (photos) => async (dispatch, getState) => {
        dispatch({
            type: addPhotoType,
            photos
        });

        // Photo processing API
        var processedPhotoResults = await StrangerService.processPhotos(photos);
        dispatch({
            type: processPhotoType,
            processedPhotoResults
        });
        
        // Reverse image search API
        var reverseImageSearchResults = await StrangerService.reverseImageSearch(photos);
        dispatch({
            type: reverseImageSearchType,
            reverseImageSearchResults
        });
    },
    addStrangerInfo: (info) => async (dispatch, getState) => {
        dispatch({
            type: addStrangerInfoType,
            info
        });

        // White pages API
        var identityCheckResults = await StrangerService.addStrangerInfo(info);        
        dispatch({
            type: identityCheckType,
            identityCheckResults
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

    if (action.type === identityCheckType) {
        return { ...state, identityCheckResults: action.identityCheckResults }
    }

    return state;
};
