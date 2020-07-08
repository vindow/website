'use strict';

const config = require('../../config/config'),
     fsutil = require('filestore-utils');

module.exports = {
    storeMapFileLocal: async (mapFile, mapModel) => {
        const fileName = mapModel.name + '.bsp';
        const basePath = __dirname + '/../../public/maps';
        const fullPath = basePath + '/' + fileName;
        const downloadURL = config.baseUrl + '/api/maps/' + mapModel.id + '/download';

        const hash = fsutil.getBufferHash(mapFile.data);
        await mapFile.mv(fullPath);
        return {
            downloadURL: downloadURL,
            hash: hash,
        }
    }
}