'use strict';

module.exports = (sequelize, type) => {
	return sequelize.define('report', {
		data: type.STRING, // everything's an int except for users...
		type: type.SMALLINT,
		category: type.SMALLINT,
		message: type.STRING(1000),
		resolved: {
			type: type.BOOLEAN,
			defaultValue: false,
		},
		resolutionMessage: type.STRING(1000),
	})
};
