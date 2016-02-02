namespace PlayLend.Controllers {
    export class UserProfileController {
        public boardgames;
        public boardgame;

        public addGame(boardgame) {
            
            this.$http.post("api/userprofile/addgame", boardgame)
                .then((reponse) => {
                    console.log("Game Added successfully");
                    this.userGames();    
                                   
                });
            
        }

        public userGames() {
            this.$http.get("api/userprofile/")
                .then((reponse) => {
                    this.boardgames = reponse.data;
                });
        }

        public deleteGame(id: number) {
            this.$http.delete(`api/userprofile/games/${id}`)
                .then((reponse) => {
                    this.userGames();
                });
        }

        constructor(private $http: ng.IHttpService) {
            this.userGames();
        }
    }
}