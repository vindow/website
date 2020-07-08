'use strict';

module.exports = {
    getFileHash: (mapPath) => {
        return new Promise((resolve, reject) => {
            const hash = crypto.createHash('sha1').setEncoding('hex');
            fs.createReadStream(mapPath).pipe(hash)
                .on('error', err => reject(err))
                .on('finish', () => {
                    resolve(hash.read())
                });
        });
    },

    getBufferHash: (buf) => {
        const hash = crypto.createHash('sha1');
        hash.update(buf);
        return hash.digest('hex');
    }
}