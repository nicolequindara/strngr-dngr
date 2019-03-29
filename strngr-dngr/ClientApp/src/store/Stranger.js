import { StrangerService } from "../services/StrangerService";

const initType = "STRANGER_INIT";
const addPhotoType = "ADD_PHOTO";
const processPhotoType = "PROCESS_PHOTO";
const reverseImageSearchType = "REVERSE_IMAGE_SEARCH";
const performIdentityCheckType = "ADD_STRANGER_INFO";
const identityCheckType = "CHECK_IDENTITY";
const offenderLookupType = "OFFENDER_LOOKUP";

const initialState = {
    photos: null,
    processedPhotoResults: null,
    reverseImageSearchResults: null,
    info: null,
    identityCheckResults: null,
    offenderLookupResults: null
}

export const actionCreators = {
    init: () => (dispatch) => {
        dispatch({ type: initType });
    },
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
    performIdentityCheck: (info) => async (dispatch, getState) => {
        dispatch({
            type: performIdentityCheckType,
            info
        });

        // White pages API
        var identityCheckResults = await StrangerService.performIdentityCheck(info);        
        dispatch({
            type: identityCheckType,
            identityCheckResults
        });
        
        // Offender lookup API
        var offenderLookupResults = await StrangerService.performOffenderLookup(info);
        dispatch({
            type: offenderLookupType,
            offenderLookupResults
        });
    }
};

export const reducer = (state, action) => {
    state = state || initialState;
    if (action.type == initType) {
        return initialState;
    }

    if (action.type == addPhotoType) {
        return { ...state, photos: action.photos }
    }

    if (action.type === processPhotoType) {
        return { ...state, processedPhotoResults: action.processedPhotoResults }
    }
    
    if (action.type === reverseImageSearchType) {
        return { ...state, reverseImageSearchResults: action.reverseImageSearchResults }
    }

    if (action.type === performIdentityCheckType) {
        return { ...state, info: action.info }
    }

    if (action.type === identityCheckType) {
        return { ...state, identityCheckResults: action.identityCheckResults }
    }

    if(action.type === offenderLookupType) {
        return {...state, offenderLookupResults: action.offenderLookupResults}
    }

    return state;
};
