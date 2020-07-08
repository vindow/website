'use strict';

const B2 = require('backblaze-b2'),
    config = require('../../config/config'),
    fsutil = require('filestore-utils');

const b2 = new B2({
    applicationKeyId: config.storage.b2.appKeyID,
    applicationKey: config.storage.b2.appKey,
});

module.exports = {

    storeFileCloud: async (mapFileBuffer, fileName) => {
        const hash = await fsutil.getBufferHash(mapFileBuffer);

        await b2.authorize();
        const uploadRequestResponse = await b2.getUploadUrl(config.storage.b2.bucketID);
        const response = await b2.uploadFile({
            uploadUrl: uploadRequestResponse.data.uploadUrl,
            uploadAuthToken: uploadRequestResponse.data.authorizationToken,
            fileName: fileName,
            data: mapFileBuffer,
            hash: hash,
        })

        console.log('UPLOAD SUCCESS!')
        console.log(response.data);

        return {
            downloadURL: config.storage.b2.bucketURL + fileName,
            hash: hash,
        }
    },
}