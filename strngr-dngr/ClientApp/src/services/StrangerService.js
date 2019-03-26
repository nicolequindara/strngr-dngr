import axios from "axios";

export const StrangerService = {
    test: () => {
        return axios.post("api/photo/test").then(resp => {
                console.log(resp);
                return resp.data;
            })
            .catch(err => {
                console.log(err);
                return err;
            });
    },
    uploadPhotos: (photos) => {
        axios.get("imageknowledge", {
                data: photos
            }).catch((err) => {
                console.log(err)
            })
            .then((resp) => {
                return resp.data;
            });
    }
}