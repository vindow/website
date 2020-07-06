'use strict';

module.exports = (sequelize, type) => {
	return sequelize.define('runZoneStats', {
		zoneNum: {
			type: type.SMALLINT,
			defaultValue: 0,
		},
	})
};
