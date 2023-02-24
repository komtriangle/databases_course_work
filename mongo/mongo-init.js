db.createUser(
    {
        user: "films_user",
        pwd: "films_password",
        roles: [
            {
                role: "readWrite",
                db: "films_db"
            }
        ]
    }
);

db = db.getSiblingDB('films_db');
db.createCollection('films');
db.createCollection('actors');