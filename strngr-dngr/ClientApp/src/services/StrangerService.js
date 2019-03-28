import axios from "axios";

export const StrangerService = {
    processPhotos: (photos) => {
        var formData = new FormData();
        for (var i = 0; i < photos.length; ++i) {
            formData.append(`photo${i}`, photos[i]);
        }

        return axios.post("api/PhotoProcessing/GetProcessedPhotoData",
            formData
        ).then((resp) => {
            console.log("StrangerService.processPhotos", resp);
            return resp;
        }).catch((err) => {
            console.log(err);
        });
    },
    reverseImageSearch: (photos) => {
        var imageUrls = [];

        for (var i = 0; i < photos.length; ++i) {
            var imgUrl = window.URL.createObjectURL(photos[i]);
            imageUrls.push(imgUrl);
        }
        
        return axios.post("api/ReverseImageSearch/Search", imageUrls).then((resp) => {
            console.log("StrangerService.reverseImageSearch", resp);

            imageUrls.map(url => { window.URL.revokeObjectURL(url) });
            return resp.data;
        }).catch((err) => {
            console.log(err);

            imageUrls.map(url => { window.URL.revokeObjectURL(url) });
            return err;
        });

    }
}