'use strict';

module.exports = (sequelize, type) => {
	return sequelize.define('mapTrackStats', {
		completions: {
			type: type.INTEGER,
			defaultValue: 0,
		},
		uniqueCompletions: {
			type: type.INTEGER,
			defaultValue: 0,
		},
	})
};
