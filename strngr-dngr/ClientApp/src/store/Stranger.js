import {StrangerService} from "../services/StrangerService";

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
  addPhoto: (photos) => async(dispatch, getState) => {
    // Call API
    const ret = await StrangerService.test();
    // StrangerService.uploadPhotos(photos).then((resp) => {
    //   console.log(resp);
    // }).catch((err) => { 
    //   console.log(err);
    // });

    
    return ({ type: addPhotoType, photos });    
  },
  addStranger: (info) => ({ type: addStrangerInfoType, info })
};

export const reducer = (state, action) => {
  state = state || initialState;

  if(action.type === addPhotoType) {
    return { ...state, photos: action.photos }
  }

  if(action.type === addStrangerInfoType) {
    return { ...state, info: action.info }
  }

  return state;
};
