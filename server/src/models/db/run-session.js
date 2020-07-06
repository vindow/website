'use strict';

module.exports = (sequelize, type) => {
	return sequelize.define('runSession', {
		id: {
			type: type.BIGINT,
			primaryKey: true,
			autoIncrement: true
		},
		trackNum: type.SMALLINT,
		zoneNum: type.SMALLINT,
	})
};
