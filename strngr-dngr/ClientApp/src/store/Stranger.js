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
  addPhoto: () => ({ type: addPhotoType}),
  addStranger: () => ({ type: addStrangerInfoType})
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
