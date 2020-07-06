'use strict';

module.exports = (sequelize, type) => {
	return sequelize.define('mapZoneTrigger', {
		type: type.SMALLINT,
		pointsHeight: type.FLOAT,
		pointsZPos: type.FLOAT,
		points: type.JSON,
	})
};
