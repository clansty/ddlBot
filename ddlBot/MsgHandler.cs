using CornSDK;

namespace ddlBot
{
    public class MsgHandler : ICornEventHandler
    {
        public void OnFriendMsg(FriendMsgArgs e)
        {
            
        }

        public void OnTempMsg(TempMsgArgs e)
        {
            
        }

        public void OnGroupMsg(GroupMsgArgs e)
        {
            if (e.FromGroup != C.workingGroup) return;
            var ret = Cmds.RunCommand(e.FromQQ, e.Msg);
            if (ret != null)
            {
                e.Reply(ret);
            }
        }

        public void OnFriendRequest(FriendRequestArgs e)
        {
            
        }

        public void OnGroupInviteRequest(GroupRequestArgs e)
        {
            
        }

        public void OnGroupJoinRequest(GroupRequestArgs e)
        {
            
        }

        public void OnGroupAddMember(GroupMemberChangedArgs e)
        {
            
        }

        public void OnGroupLeftMember(GroupMemberChangedArgs e)
        {
            
        }
    }
}