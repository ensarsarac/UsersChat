using UsersChat.Data.Entities;

namespace UsersChat.Data.Repository.DraftRepo
{
    public interface IDraftRepository
    {
        List<Draft> GetDraftList(int id);
        Draft GetDraftById(int id);
        void RemoveDraft(int id);
        void AddDraft(Draft draft);
    }
}
