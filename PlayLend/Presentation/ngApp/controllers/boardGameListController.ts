namespace PlayLend.Controllers {
    export class BoardGameListController {
        public boardgames;

        constructor(private $http: ng.IHttpService) {
            $http.get("api/boardgamelist/")
                .then((reponse) => {
                    this.boardgames = reponse.data;
                });
        }
    }
}