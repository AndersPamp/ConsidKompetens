export default {
	page: {
		Ok: true,
		Message: ''
		Framework: {
			Api: {
				GetuUsersUrl: 'https://localhost:3000/users',
				ReturnUrl: 'https://localhost:3000/return',
				Links: {
					LinkedInUrl: 'https://www.linkedin.com/company/consid-ab/',
					FacebookUrl: 'https://www.facebook.com/consid.se',
					TwitterUrl: 'https://twitter.com/consid_ab',
					IstagramUrl: 'https://www.instagram.com/consid_ab/'
				},
				Offices: [{
					Id: '',
					Created: 'DateTime',
					Modified: 'DateTime',
					City: [
						'Jönköping', 'Stockholm', 'Uppsala', 'Göteborg', 'Malmö', 'Linköping',
					'Norrköping', 'Värnamo', 'Växjö', 'Ljungby', 'Örebro', 'Västerås', 'Sundsvall',
					'Helsingborg', 'Karlshamn', 'Karlskrona', 'Gävle', 'Nyköping', 'Borås', 'Kalmar'
					],
					Competences: [],
					Projeckts: []
				}]
			}
		},
		Consultants: [{
			Id: '',
			Created: 'DataTime',
			Modified: 'DataTime',
			OwnerId: '',
			FirstName: 'John',
			LastName: 'Doe',
			AboutMe: 'Hi I´m John Doe',
			Role: {},
			Title: 'Backend developer',
			OfficeId: '',
			ImageModel: {},
			Competences: {},
			Experience: {},
			Projeckts: [{
				Id: '',
				Created: '',
				Modified: '',
				Name: 'Suez',
				Description:'Suez backend project',
				Role: {},
				Techniques: {},
				TimePeriod:'2019.08.28-2019.10.10'
			}]
		}]
	}
"PageTitle":"",
"Ok":true/false,
"Message":"",
	"Framework":{
		"Api":{"GetUserUrl":"",
		"ReturnUrl":"",
		"Links":{"LinkedInUrl":"", "FacebookUrl":"", "TwitterUrl":"", "InstagramUrl":""},
		"Offices":[{"Id":int, "Created":DateTime, "Modified":DateTime, "City":""}],
		"Competences":[Competences],
		"Projects":[Projects]
		}
	,
	"Consultants":[{"Id":int, "Created":DateTime, "Modified":DateTime,"OwnerId":Guid,
	"FirstName":"", "LastName":"","AboutMe":"","Role":enum,
	"Title":"", "OfficeId":int, "ImageModel":{}, "Competences":[Competences],
	"Experience":ushort}],
	
	"Projects":[{"Id":int, "Created":DateTime, "Modified":DateTime, "Name":"", 
	"Description":"", "Role":enum, "Techniques":[enum], "TimePeriod":""}]
