'use strict';

module.exports = (sequelize, type) => {
	return sequelize.define('mapZone', {
		zoneNum: type.SMALLINT,
	}, {
		indexes: [
			{
				fields: ['zoneNum']
			}
		]
	})
};
