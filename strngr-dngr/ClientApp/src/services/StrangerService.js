import axios from "axios";

export const StrangerService = {
    processPhotos: async (photos) => {
        var formData = new FormData();
        for (var i = 0; i < photos.length; ++i) {
            formData.append(`photo${i}`, photos[i]);
        }

        return await axios.post("api/PhotoProcessing/GetProcessedPhotoData",
            formData
        ).then((resp) => {
            console.log("StrangerService.processPhotos", resp);
            return resp.data;
        }).catch((err) => {
            console.log(err);
        });
    },
    reverseImageSearch: async (photos)  => {
        var imageUrls = [];

        for (var i = 0; i < photos.length; ++i) {
            var imgUrl = window.URL.createObjectURL(photos[i]);
            imageUrls.push(imgUrl);
        }
        
        return await axios.post("api/ReverseImageSearch/Search", imageUrls).then((resp) => {
            console.log("StrangerService.reverseImageSearch", resp.data);
            imageUrls.map(url => { window.URL.revokeObjectURL(url) });
            return resp.data;
        }).catch((err) => {
            console.log(err);

            imageUrls.map(url => { window.URL.revokeObjectURL(url) });
            return err;
        });
    },
    performIdentityCheck: async (info) => {
        return await axios.post("api/WhitePages/IdentityCheck", info).then((resp) => {
            console.log("StrangerService.performIdentityCheck", resp.data);
            return resp.data;
        }).catch((err) => {
            console.log(err);
        });
    },
    performOffenderLookup: async (info) => {
        return await axios.post("api/OffenderLookup/Search", info).then((resp) => {
            console.log("StrangerService.performOffenderlookup", resp.data);
            return resp.data;
        }).catch((err) => {
            console.log(err);
        })
    }
}