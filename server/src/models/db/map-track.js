'use strict';

module.exports = (sequelize, type) => {
	return sequelize.define('mapTrack', {
		trackNum: type.SMALLINT,
		numZones: type.SMALLINT,
		isLinear: type.BOOLEAN,
		difficulty: type.SMALLINT,
	})
};
