import axios from "axios";

export const StrangerService = {
    uploadPhotos: (photos) => {
        axios.get("api/PhotoProcessing/GetProcessedPhotoData",
            {
                data: photos
            });
    }
}