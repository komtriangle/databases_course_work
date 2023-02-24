db.createUser(
    {
        user: "films_user",
        pwd: "films_password",
        roles: ["root"]
    }
);

db = db.getSiblingDB('films_db');
db.createCollection('films');
db.createCollection('actors');